<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="LibrosAEP.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .ImgItemListar {
            height: 4rem;
            border: double;
        }
    </style>
    <div class="ContenedorPrincipal">
        <div class="container-listas">

            <div class="d-flex justify-content-end" style="margin-bottom: 20px">
                <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Libro" CssClass="btn btn-primary" type="submit" OnClick="BtnAlta_Click" />

            </div>

            <table>

                <thead>
                    <tr style="color: #000000;background-color:  plum;">
                        <th scope="col">Titulo</th>
                        <th scope="col">Autor</th>
                        <th scope="col">Imagen Tapa</th>
                        <th scope="col">Dueña</th>
                        <th scope="col">Genero</th>
                        <th scope="col">Disponible</th>
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M192 64C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192s-86-192-192-192H192zm192 96a96 96 0 1 1 0 192 96 96 0 1 1 0-192z" />
                            </svg></th>
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M384 128c70.7 0 128 57.3 128 128s-57.3 128-128 128H192c-70.7 0-128-57.3-128-128s57.3-128 128-128H384zM576 256c0-106-86-192-192-192H192C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192zM192 352a96 96 0 1 0 0-192 96 96 0 1 0 0 192z" />
                            </svg></th>
                        <th scope="col">
                            <svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 512 512">
                                <!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. -->
                                <path d="M368.4 18.3L312.7 74.1 437.9 199.3l55.7-55.7c21.9-21.9 21.9-57.3 0-79.2L447.6 18.3c-21.9-21.9-57.3-21.9-79.2 0zM288 94.6l-9.2 2.8L134.7 140.6c-19.9 6-35.7 21.2-42.3 41L3.8 445.8c-3.8 11.3-1 23.9 7.3 32.4L164.7 324.7c-3-6.3-4.7-13.3-4.7-20.7c0-26.5 21.5-48 48-48s48 21.5 48 48s-21.5 48-48 48c-7.4 0-14.4-1.7-20.7-4.7L33.7 500.9c8.6 8.3 21.1 11.2 32.4 7.3l264.3-88.6c19.7-6.6 35-22.4 41-42.3l43.2-144.1 2.8-9.2L288 94.6z" />
                            </svg></th>

                    </tr>

                </thead>
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <tbody>
                            <tr>


                                <td><%# Eval("Titulo")%></td>
                                <td><%# Eval("Autor")%></td>
                                <td>
                                    <img src='<%# Eval("ImgTapa") %>' class="ImgItemListar" alt="Imagen del producto" />
                                </td>
                                <td><%# Eval("Usuario.Nombre")%></td>
                                <td><%# Eval("Genero")%></td>
                                <td><%# Eval("Activo")%></td>
                                <td>

                                    <asp:Button Text="Desactivar" CssClass="btn btn-danger" ID="btnEliminar" OnClientClick="return confirm('Esta seguro de que quiere dejar INACTIVO este libro ?');" OnClick="btnEliminar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%> ' />
                                </td>
                                <td>
                                    <asp:Button Text="Activar" CssClass="btn btn-success" ID="btnActivar" OnClientClick="return confirm('¿Está seguro de que quiere ACTIVAR este libro?');" OnClick="btnActivar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id") %>' />
                                </td>
                                <td>
                                    <asp:Button Text="Modificar" CssClass="btn btn-secondary" ID="btnModificar" AutoPostBack="true" OnClick="btnModificar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%>' />
                                </td>

                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:Label ID="lblMensaje" ForeColor="red" runat="server" CssClass="message" Visible="false"></asp:Label>

        </div>

    </div>
</asp:Content>
