public class AuthenticationService
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IService<User> _userService;
        private readonly AppSettings _appSettings;

        public AuthenticationService(ITokenProvider tokenProvider, IService<User> baseService, AppSettings appSettings)
        {
            _tokenProvider = tokenProvider;
            _userService = baseService;
            _appSettings = appSettings;
        }

        public async Task<LoginResponse> Authenticate(LoginRequest loginRequest)
        {

            var userInDb = await _userService.Get(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if (userInDb != null)
            {
                var loginResponse = new LoginResponse
                {
                    Token = _tokenProvider.GenerateToken(userInDb, _appSettings.Secret)
                };
                userInDb.Password = string.Empty;
                loginResponse.User = userInDb;
                return loginResponse;
            }

            throw new Exception("validation.user.notFound");
        }
    }