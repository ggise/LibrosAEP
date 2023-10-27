<%@ Page Title="" Language="C#" EnableEventValidation="false"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiLectura.aspx.cs" Inherits="LibrosAEP.MiLectura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .ImgItemListar {
            height: 4rem;
            border: double;
        }
    </style>
    <div class="ContenedorPrincipal">
        <div class="container-listas">

            <table>



                <%if (LibroSeleccionado != null)

                    {%>
                <thead>
                    <tr style="color: #000000; background-color: plum;">
                        <th scope="col">Titulo</th>
                        <th scope="col">Autor</th>
                        <th scope="col">Imagen Tapa</th>
                        <th scope="col">Dueña</th>
                        <th scope="col">Genero</th>
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M192 64C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192s-86-192-192-192H192zm192 96a96 96 0 1 1 0 192 96 96 0 1 1 0-192z" />
                            </svg></th>


                    </tr>

                </thead>


                <itemtemplate>
                    <tbody>
                        <tr>


                            <td><%:LibroSeleccionado.Titulo%></td>
                            <td><%:LibroSeleccionado.Autor%></td>
                            <td>
                                <img src='<%:LibroSeleccionado.ImgTapa%>' class="ImgItemListar" alt="Imagen del producto" />
                            </td>
                            <td><%:LibroSeleccionado.Usuario.Nombre%></td>
                            <td><%:LibroSeleccionado.Genero.Descripcion%></td>
                            <td>

                                <asp:Button Text="Solicitar" CssClass="btn btn-success" ID="btnSolicitar" OnClick="btnSolicitar_Click" runat="server" CommandArgument="<%# LibroSeleccionado.Id%>" CommandName="AlbumId" />
                            </td>


                        </tr>
                    </tbody>
                </itemtemplate>

                <%  }
                    if (listaLeidos != null && listaLeidos.Count > 0 || listaLeyendo != null && listaLeyendo.Count > 0)
                    {

                %>
                <tr style="color: #000000; background-color: plum">
                    <th scope="col">Titulo</th>

                    <th scope="col">
                        <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                            <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                            <path d="M192 64C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192s-86-192-192-192H192zm192 96a96 96 0 1 1 0 192 96 96 0 1 1 0-192z" />
                        </svg></th>


                </tr>

                <%  }%>
                <asp:Repeater runat="server" ID="repRepetidor">

                    <ItemTemplate>
                        <tbody>
                            <tr>

                                <% if (listaLeyendo != null && listaLeyendo.Count > 0)
                                    {

                                %>
                                <td><%# Eval("Libro.Titulo")%></td>

                                <td>
                                    <asp:Button Text="Devolver" CssClass="btn btn-success" ID="btnDevolver" OnClick="btnDevolver_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%>' />
                                </td>


                                <%} %>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>

                <%if (listaLeidos != null && listaLeidos.Count > 0)
                    {

                %>
                <itemtemplate>
                    <tbody>
                        <%foreach (Dominio.Leyendo leyendo in listaLeidos)

                            {  %>
                        <tr>
                            <td><%:leyendo.Libro.Titulo%></td>

                            <td>Leido</td>
                        </tr>
                        <%} %>
                    </tbody>
                </itemtemplate>

                <%  } %>
            </table>
            <asp:Label ID="lblMensaje" ForeColor="Plum" runat="server" CssClass="message" Visible="false"></asp:Label>

        </div>

    </div>

</asp:Content>
