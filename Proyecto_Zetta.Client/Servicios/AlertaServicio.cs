using Microsoft.JSInterop;
using static Proyecto_Zetta.Client.Pages.Obra.ListaContrato;

public class AlertaServicio
{
    private readonly IJSRuntime _jsRuntime;

    public AlertaServicio(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    //public async Task<SwalResult> ConfirmDeletion(string title, string text)
    //{
    //    // Invoca el script de SweetAlert con los parámetros necesarios
    //    return await _jsRuntime.InvokeAsync<SwalResult>("Swal.fire", new
    //    {
    //        title,
    //        text,
    //        icon = "warning",
    //        showCancelButton = true,
    //        confirmButtonColor = "#3085d6",
    //        cancelButtonColor = "#d33",
    //        confirmButtonText = "Sí, eliminarlo!",
    //        cancelButtonText = "Cancelar"
    //    });
    //}
}
