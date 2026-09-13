

using System.Security.Cryptography.Xml;

namespace NibbssNPSPaymentStack.Business.Models.Response
{
    public sealed record CustomError(string code, string message)
    {
        private static readonly string _badRequest = "BadRequest";
        private static readonly string _validationErrorCode = "ValidationErrror";
        private static readonly string _DbPersistError = "Failed To Save";
        private static readonly string _MessageIdNotFoundError = "MessageId not found";
        private static readonly string _failedAccountVerification = "Failed Account Verification";
        public static CustomError None => new(string.Empty,string.Empty);

        public static CustomError MessageIdNotFound(string message) => new CustomError(_MessageIdNotFoundError, message);
        public static CustomError BadRequestError(string message) => new CustomError(_badRequest, message);
        public static CustomError ValidationError(string message) => new CustomError(_validationErrorCode, message);
        public static CustomError PersistFailed(string message) => new CustomError(_DbPersistError, message);
        public static CustomError FailedAccountVerification(string message) => new CustomError(_failedAccountVerification, message);

    }
}
