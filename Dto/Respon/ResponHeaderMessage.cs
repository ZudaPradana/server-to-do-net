namespace SimpleAppCRUD.DTO.Respon
{
    public class ResponHeaderMessage
    {
        public static ResponHeader GetRequestSuccess()
        {
            return new ResponHeader("200", true, "Request successfully processed.");
        }

        public static ResponHeader GetDataCreated()
        {
            return new ResponHeader("201", true, "Session successfully created.");
        }

        public static ResponHeader GetBadRequestError()
        {
            return new ResponHeader("400", false, "Please check the data you entered and try again.");
        }

        public static ResponHeader GetDataAlreadyExist()
        {
            return new ResponHeader("409", false, "Email is already registered.");
        }

        public static ResponHeader GetUnauthorized()
        {
            return new ResponHeader("401", false, "Username not found or password incorrect.");
        }

        public static ResponHeader getForbiddenAccess()
        {
            return new ResponHeader("403", false, "You are not allowed to access this resource.");
        }

        public static ResponHeader getInputValidationError()
        {
            return new ResponHeader("422", false, "The data you entered is invalid, please try again.");
        }

        public static ResponHeader GetDataNotFound()
        {
            return new ResponHeader("404", false, "Data / page not found.");
        }

        public static ResponHeader GetServerUnknownError()
        {
            return new ResponHeader("500", false, "There is a problem with the server, contact the administrator for more information.");
        }
    }
}
