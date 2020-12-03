using CA.ProductCoreApp.Entities.Interfaces;

namespace CA.ProductCoreApp.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        private string _token;
        public JwtAccessToken(string token)
        {
            _token = token;
        }
        public string Token 
        { 
            get 
            { 
                return _token; 
            } 
        }
    }
}
