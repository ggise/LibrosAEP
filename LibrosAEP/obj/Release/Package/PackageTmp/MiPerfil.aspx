<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="LibrosAEP.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="CuerpoRegistro">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-md-9 col-lg-7 col-xl-5">
                    <div class="card" style="border-radius: 15px;">
                        <div class="card-body p-4">
                            <div class="d-flex text-black">
                                <div class="flex-shrink-0">
                                    <img src="https://img.wattpad.com/cover/238765713-288-k320208.jpg"
                                        alt="Generic placeholder image" class="img-fluid"
                                        style="width: 180px; border-radius: 10px;">
                                </div>
                                <% if (perfil != null)
                                    {

                                %>
                                <div class="flex-grow-1 ms-3">
                                    <h5 class="mb-1"><%:perfil.Nombre %> <%:perfil.Apellido %></h5>
                                    <p class="mb-2 pb-1" style="color: #2b2a2a;"><%:perfil.Email %></p>
                                    <div class="d-flex justify-content-start rounded-3 p-2 mb-2"
                                       // style="background-color: #efefef;">
                                        <div>
                                            <p class="small text-muted mb-1">Libros</p>
                                            <p class="mb-0"><%:cantLibros %></p>
                                        </div>
                                        <div class="px-3">
                                            <p class="small text-muted mb-1"></p>
                                            <p class="mb-0"></p>
                                        </div>
                                        <div>
                                            <p class="small text-muted mb-1">Libros Leidos</p>
                                            <p class="mb-0"><%:cantLeidos %></p>
                                        </div>
                                    </div>
                                    <div class="d-flex pt-1">
                                         
                                        <asp:Button text="Modificar perfil" ID="btnDatos"  OnClick="btnDatos_Click" runat="server" CssClass="btn btn-success me-1 flex-grow-1"></asp:Button>
                                        <asp:Button text="Mi Lectura" id="btnLibros"  OnClick="btnLibros_Click"  runat="server" Class="btn btn-success flex-grow-1"></asp:Button>
                                    </div>
                                     <div class="d-flex pt-1">
                                         
                                        <asp:Button text="Sumar tus Libros" ID="btnSumarLibros"  OnClick="btnSumarLibros_Click" runat="server" CssClass="btn btn-success me-1 flex-grow-1"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
       
        <%}
        %>
   </div>   
</asp:Content>
