<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto_Programado_1.APP.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Assets/Styles/styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Source+Sans+Pro:ital,wght@0,400;0,600;1,400&display=swap" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="https://getbootstrap.com/docs/4.1/assets/js/vendor/popper.min.js"></script>
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <title>Registro de Usuario</title>
</head>
<body style="background-image: url(Assets/images/Fondo-Libreria.jpg)">
    <form id="form1" runat="server">
        <div class="container w-50 mt-5 float-none">
            <div class="divLogin">
                <div class="card-body">
                    <h1 style="text-align: center; margin-bottom: 5px; font-size: 45px; color: #0a0a0a;">Registro de Cuenta</h1>
                    <hr />
                    <div class="form-group inputWithIcon" style="margin-top: 45px;">
                        <input runat="server" style="box-shadow: 8px 5px 8px #888888;" type="text" class="form-control" id="txtNombreUsuario" placeholder="Nombre de usuario" required="required" />
                        <i class="fa fa-user"></i>
                    </div>
                    <div class="form-group inputWithIcon">
                        <input runat="server" style="box-shadow: 8px 5px 8px #888888;" type="email" class="form-control" id="txtEmail" placeholder="Correo Electronico" required="required" />
                        <i class="fa fa-envelope"></i>
                    </div>
                    <div class="form-group inputWithIcon">
                        <input runat="server" style="box-shadow: 8px 5px 8px #888888;" type="password" class="form-control" id="txtPassword" placeholder="Contraseña" required="required" />
                        <i class="fa fa-lock" aria-hidden="true"></i>
                    </div>
                </div>
                <asp:Button ID="btnRegistrarUsuario" runat="server" class=" btn btn-success" Text="Crear Usuario" OnClick="btnRegistrarUsuario_Click" />
            </div>
        </div>
        <div id="divModal" runat="server"></div>
        <script src="../Scripts/MensajeModal.js"></script>
    </form>
</body>
</html>
