<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LibrosxUsuario.aspx.cs" Inherits="LibrosAEP.LibrosxUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row row-cols-1 row-cols-md-5 g-4 ">
            <% if (listaLibro != null)
                {
                    foreach (Dominio.Libro Libro in listaLibro)
                    {
            %>
            <updatepanel>
                <contentemplate>
                    <div class="card">
                        <img src="<%:Libro.ImgTapa%>" class="ImgCard" alt=".Imagen del producto">
                        <div class="bodyvinilo">
                            <p class="card-text">"<%:Libro.Titulo %>"</p>
                            <p class="card-text"><%:Libro.Autor %></p>
                            <p class="card-precio">Dueña: <%:Libro.Usuario.Nombre %></p>
                            <div class="col">
                                <a href="Detalle.aspx?iddetalle=<%:Libro.Id %>" class="btn btn-success">Ver Detalle</a>
                                <a href="LibrosxFiltrado.aspx?id=<%:Libro.Id %>"></a>
                                <a href="MiLectura.aspx?id=<%:Libro.Id %>" class="btn btn-success">Quiero leerlo</a>

                            </div>
                        </div>
                    </div>
                    <div>

                        <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>
                    </div>



                </contentemplate>
            </updatepanel>

            <%}
                }
            %>
        </div>
    </div>
</asp:Content>
