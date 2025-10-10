using System.Globalization;
using System.Reflection;

namespace Amethyst925.Windows.Utils;

public static class MyConstants
{
    #region Connection String's
    public static string? CONNECTION_STRING { get; set; }
    public static bool IS_INITIAL { get; set; }
    #endregion

    #region Constants
    public static string? DEVICE_ID { get; set; }
    public static CultureInfo MY_CULTURE = new("es-SV");
    private static Version? _version = Assembly.GetEntryAssembly()?.GetName().Version;
    public static string APP_VERSION => $"{_version?.Major}.{_version?.Minor}.{_version?.Build}.{_version?.Revision}";
    public static string SAVE_COMMAND => "Amethyst925-SaveMe";
    #endregion

    #region Text's
    public static string MSG_ERROR_TEXTBOX_EMPTY => "Debe asignar una descripción válida";
    public static string MSG_ERROR_TEXTBOX_EMPTY_VALUE => "Debe asignar un valor válido";
    public static string MSG_ERROR_TEXTBOX_EMPTY_CODE => "Debe asignar un código válido";
    public static string MSG_ERROR_TEXTBOX_EMPTY_TRUCKSHIFT => "Debe asignar un turno válido";
    public static string MSG_ERROR_TEXTBOX_EMPTY_BATCH => "Debe asignar un Lote válido";
    public static string MSG_ERROR_INVALID_PRODUCT => "Producto no válido";
    public static string MSG_ERROR_INSERT => "Problema para Insertar ítem";
    public static string MSG_ERROR_UPDATE => "Problema para Actualizar ítem";
    public static string MSG_ERROR_NO_CONTEXT => "No existe el Contexto de Datos";
    public static string MSG_ERROR_INVALID_ENVIRONMENT_VARIABLES => "Verificar las Variables de Entorno de la Aplicación";
    public static string MSG_ERROR_COMBO_NOSELECTED => "Debe seleccionar un Ítem";
    public static string MSG_ERROR_DETAIL_NOSELECTED => "Debe seleccionar un registro antes";
    public static string MSG_ERROR_NO_WEIGHT => "Peso no debe ser CERO, verificar";
    public static string MSG_SET_PARAMETERS => "Favor validar las Variables de Entorno y reintentar";
    public static string MSG_SCALE_PARAMETERS => "Favor validar la Configuración de la Báscula";
    public static string MSG_ERROR_WEIGHT => "No se puede guardar el Registro de Peso, favor verficar";
    public static string MSG_ERROR_WEIGHTZERO => "El valor debe ser mayor de CERO, favor verficar";
    public static string MSG_ERROR_UNITS => "Las Unidades deben ser mayor de CERO, favor verificar";
    public static string MSG_QUESTION_CANCEL_WEIGHT => "¿Desea anular el Peso?";
    public static string MSG_QUESTION_CANCEL_LASTREADING => "¿Desea limpiar últimas pesas?";
    public static string MSG_QUESTION_CANCEL_DELETE => "A L E R T A :\n\n ¿Desea eliminar el registro seleccionado?";
    public static string MSG_QUESTION_USER_PASSWORD_DB => "¿Están correctos la configuración de la Conexión?";
    public static string MSG_RESTART_APP => "Favor verificar Parámetros en las Variables de Entorno del Usuario, validarlos y vuelva a iniciar la Aplicación";
    public static string MSG_ERROR_GETINFO => "Hubo un problema para obtener la información";
    public static string MSG_ERROR_NO_VALID_DETAIL => "Verificar lo siguiente:";
    public static string MSG_ERROR_SAVE_DETAIL_PRODUCTION_ORDER => "Problema al Guardar Detalle, verificar";
    public static string MSG_ERROR_FIELDS_HEADER => "Campos obligatorios, verificar:";
    public static string MSG_ERROR_PRINT_STICKER => "Problema para imprimir etiqueta";
    public static string MSG_ERROR_OUTOFRANGE_MINIMUN => "Fuera del rango mínimo";
    public static string MSG_ERROR_OUTOFRANGE_MAXIMUN => "Fuera del rango máximo";
    public static string MSG_WARNING_VALIDATE_LOCATIONS => "Debe confirmar Origen/Destino y Turno\nusando botón [Confirmar / Finalizar]";


    public static string TXT_INFO => "Información";
    public static string TXT_ERROR => "Error";
    public static string TXT_WARNING => "Alerta";
    public static string TXT_QUESTION => "Pregunta";
    public static string TXT_NO_EXISTS_CODE => "Código no existe";

    public static string NOTEMPTYVALIDATIONRULE => "Campo obligatorio";

    #endregion
}
