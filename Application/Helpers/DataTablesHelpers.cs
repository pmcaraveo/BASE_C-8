using System;

namespace MvcCore.Helpers
{
    public static class DataTablesHelpers
    {
        private static string btnCssClass = "btn btn-default tbl";
        public static string GetBooleanColumn(bool value)
        {
            return value ? "SI" : "NO";
        }

        public static string GetShortDateColumn(DateTime? value)
        {
            var date = value?.ToString("dd/MM/yyyy") ?? "";
            return date;
        }

        public static string GetLongDateColumn(DateTime value)
        {
            //var column = $"<p class=\"text-right\">{ value.ToString("dd/MM/yyyy HH:mm") }</p>";
            return value.ToString("dd/MM/yyyy HH:mm");
        }

        public static string GroupButtons(string urlEdit, int id, string urlSello, string urlParte, string rutaFirmada)
        {
            var ocultarFirma = rutaFirmada == null ? "hidden" : "";

            return "<div>" +
                        "<div class=\"btn-group\">" +
                            "<button type=\"button\" class=\"btn btn-link btn-sm\" data-toggle=\"dropdown\">" +
                                "<i class=\"fas fa-ellipsis-v\" aria-hidden=\"true\"></i>" +
                            "</button>" +
                            "<div class=\"dropdown-menu wrapper-dropdown-2\">" +
                                "<a class=\"" + btnCssClass + "\" href=\"" + urlParte + "\" title=\"Registrar partes\"><i class=\"fas fa-users icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" href=\"" + urlEdit + "\" title=\"Detalles\"><i class=\"fas fa-pencil-alt icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Cancelar\" onclick=\"cancelar(" + id + ")\"><i class=\"fas fa-trash-alt icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" href=\"" + urlSello + "\" title=\"Sello\"><i class=\"fas fa-stamp icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\"  title=\"Enviar a juzgado\" onclick=\"sendChecks(" + id + ")\"><i class=\"fas fa-paper-plane icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" href=" + rutaFirmada + " title=\"Ver acuse firmado\" " + ocultarFirma + " target=\"_blank\"><i class=\"fas fa-file-signature\"></i></a>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }

        public static string GroupButtons(string urlEdit, int id, string urlSello)
        {
            return "<div class=\"tools\">" +
                        "<a class=\"" + btnCssClass + "\" href=\"" + urlEdit + "\" title=\"Detalles\"><i class=\"fas fa-pencil-alt\"></i></a>" +
                        "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Cancelar\" onclick=\"cancelar(" + id + ")\"><i class=\"fas fa-trash-alt\"></i></a>" +
                        "<a class=\"" + btnCssClass + "\" href=\"" + urlSello + "\" title=\"Sello\"><i class=\"fas fa-stamp\"></i></a>" +
                    "</div>";
        }

        public static string GroupButtonsSimple(string urlEdit, int id, int personaId, int tipoPersonaId)
        {
            return "<div>" +
                        "<div class=\"btn-group\">" +
                            "<button type=\"button\" class=\"btn btn-link btn-sm\" data-toggle=\"dropdown\">" +
                                "<i class=\"fas fa-ellipsis-v\" aria-hidden=\"true\"></i>" +
                            "</button>" +
                             "<div class=\"dropdown-menu wrapper-dropdown-2\">" +
                                "<a class=\"" + btnCssClass + "\" href=\"" + urlEdit + "\" title=\"Detalles\"><i class=\"fas fa-pencil-alt icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Eliminar\" onclick=\"eliminar(" + id + ", " + personaId + ", " + tipoPersonaId + ")\"><i class=\"fas fa-trash-alt icon\"></i></a>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }

        public static string GroupButtonAnterior(string urlEdit)
        {
            return "<div class=\"tools\">" +
                        "<a class=\"" + btnCssClass + "\" href=\"" + urlEdit + "\" title=\"Detalles\"><i class=\"fas fa-pencil-alt\"></i></a>" +
                    "</div>";
        }

        public static string ButtonEdit(string urlEdit)
        {
            return "<div >" +
                        "<a class=\"" + btnCssClass + "\" href=\"" + urlEdit + "\" title=\"Detalles\"><i class=\"fas fa-pencil-alt\"></i></a>" +
                    "</div>";
        }

        public static string ButtonFirma(int id, string urlDescargar, string user)
        {
            //var firmado = rutaFirmado != null ? " " : "hidden";

            return "<div>" +
                        "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Ver archivos pdf\" onclick=\"verPdf(" + id + ", " + "'" + user + "'" + ")\" ><i class=\"fas fa-file-pdf icon\"></i></a>" +
                    //"<a class=\"" + btnCssClass + "\" href=\"" + urlDescargar + "\" title=\"Descargar documento\" target=\"_blank\"><i class=\"fas fa-download icon\"></i></a>" +
                    "</div>";
        }
        public static string GroupButtonsSimple2(int id)
        {
            return "<div>" +
                        "<div class=\"btn-group\">" +
                            "<button type=\"button\" class=\"btn btn-link btn-sm\" data-toggle=\"dropdown\">" +
                                "<i class=\"fas fa-ellipsis-v\" aria-hidden=\"true\"></i>" +
                            "</button>" +
                             "<div class=\"dropdown-menu wrapper-dropdown-2\">" +
                                "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Editar\" onclick=\"editar(" + id + ")\"><i class=\"fas fa-pencil-alt icon\"></i></a>" +
                                "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Eliminar\" onclick=\"eliminar(" + id + ")\"><i class=\"fas fa-trash-alt icon\"></i></a>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }

        public static string ButtonDelete(int id)
        {
            return "<div >" +
                        "<a class=\"" + btnCssClass + "\" style=\"cursor:pointer\" title=\"Eliminar\" onclick=\"eliminarHistorial(" + id + ")\"><i class=\"fas fa-trash-alt icon\"></i></a>" +
                    "</div>";
        }

    }
}