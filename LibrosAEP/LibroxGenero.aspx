<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LibroxGenero.aspx.cs" Inherits="LibrosAEP.LibroxGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="container">
      <style="background-color: #efefef;"/>
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

                                <%if (Libro.Activo == true)
                                    {  %>
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


                                <%   }
                                    }else { %>
                                <br />No Disponible, lo estan leyendo <%
                                } %>
                            </div>
                        </div>
                    </div>
                </contentemplate>
            </updatepanel>

            <%}
                }
            %>
        </div>
    </div>
</asp:Content>

