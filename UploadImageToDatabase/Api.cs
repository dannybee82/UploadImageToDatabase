namespace MinimalAPIDemo;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoint mapping
        app.MapGet("/Images", GetAllImages);
        app.MapGet("/Images{id}", GetImageById);
        app.MapGet("/Max-id", GetMaxId);
        app.MapGet("/Count", Count);
        app.MapPost("/Image-new", InsertNewImage);
        app.MapPut("/Update-image", UpdateImage);
        app.MapDelete("/Delete-image{id}", DeleteImage);
    }

    private static async Task<IResult> GetAllImages(IImagesData data)
    {
        try
        {
            return Results.Ok(await data.GetAllImages());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetImageById(int id, IImagesData data)
    {
        try
        {
            var results = await data.GetImageById(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Count(IImagesData data)
    {
        try
        {
            var results = await data.Count();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetMaxId(IImagesData data)
    {
        try
        {
            var results = await data.GetMaxId();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> InsertNewImage(ImageData imageData, IImagesData data)
    {
        try
        {
            await data.InsertNewImage(imageData);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> UpdateImage(ImageData imageData, IImagesData data)
    {
        try
        {
            await data.UpdateImage(imageData);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteImage(int id, IImagesData data)
    {
        try
        {
            await data.DeleteImage(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

}
