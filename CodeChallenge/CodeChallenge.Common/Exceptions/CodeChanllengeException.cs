using System;
using System.Net;

namespace CodeChallenge.Common.Exceptions
{
    public class CodeChallengeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CodeChallengeException()
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public CodeChallengeException(string message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public CodeChallengeException(string message, Exception inner)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public CodeChallengeException(string message, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
