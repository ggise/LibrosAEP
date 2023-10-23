<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="LibrosAEP.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    


    <div class="how-section1">
        <div class="row">
            <div class="col-md-6 how-img">
                <% if (LibroSeleccionado != null)
                    { %>
                <% Dominio.Libro Libro = LibroSeleccionado; %>
                <img src="<%= Libro.ImgTapa %>" class="img-fluid" alt="" />
            </div>
            <div class="col-md-6">
                <h4>"<%= Libro.Titulo %>"</h4>

                <p class="artist"><b>Autor: </b><%= Libro.Autor %></p>
                <p class="genre"><b>Género: </b><%= Libro.Genero %></p>
                <p class="category"><b>Dueña: </b><%= Libro.Usuario.Nombre %></p>
                <%if (!Negocio.Seguridad.sesionActiva(Session["usuario"]))
                    {  %>

                                <a href="Login.aspx?id=<%:Libro.Id %>" class="btn btn-success">Quiero leerlo</a>

                                <a href="Login.aspx?id=<%:Libro.Id %>"></a>
                                <%}
                                    else
                                    {%>
                                    <div>                                              
                                     <a href="MiLectura.aspx?id=<%:Libro.Id %>" class="btn btn-success">Quiero leerlo</a>

                                </div>
                                <div>

                                    <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>
                                </div>


                                <%   } %>
                           

                <p class="text-muted">
                    <%= Libro.Sinopsis %>
                    <%} %>
                </p>
            </div>
        </div>

    </div>
</asp:Content>
