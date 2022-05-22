namespace Albelli.Common.Models
{
    public enum ResponseCode
    {
        Success = 200,
        InternalError = 500,
        GeneralError = 700,
        NotFound = 404,
        BadRequest = 400,
        NoContent = 204,
        Created = 201,
        Unauthorized = 401,
        Forbid = 403
    }

    public enum ProductType
    {
        PhotoBook = 1,
        Calendar = 2,
        Canvas = 3,
        Cards = 4,
        Mug = 5
    }
}
