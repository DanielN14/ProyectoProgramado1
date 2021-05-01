<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_Programado_1.APP.Login" %>

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
    <title>Login</title>
</head>

<body style="background-image: url(Assets/images/Fondo-Libreria.jpg)">
    <form id="form1" runat="server">
        <div class="container w-50 mt-5 float-none">
            <div class="divLogin">
                <div class="card-body">
                    <h1 style="text-align: center; margin-bottom: 5px; font-size: 45px; color: #0a0a0a;">Inicio de sesión</h1>
                    <hr />
                    <div class="form-group inputWithIcon" style="margin-top: 45px;">
                        <input runat="server" style="box-shadow: 8px 5px 8px #888888;" type="email" class="form-control" id="txtEmail" placeholder="Correo Electronico" required="required" />
                        <i class="fa fa-user"></i>
                    </div>
                    <div class="form-group inputWithIcon">
                        <input runat="server" style="box-shadow: 8px 5px 8px #888888; background-color: white;" type="password" class="form-control" id="txtPassword" placeholder="Contraseña" required="required" />
                        <i class="fa fa-lock" aria-hidden="true"></i>
                    </div>
                </div>
                <asp:Button ID="btnIniciarSesion" runat="server" class=" btn btn-success" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" />
                <p style="text-align: center; margin-top: 10px; font-size: 18px; color: #0a0a0a;">¿No estas registrado? <a href="Registro.aspx">Registrate aquí</a></p>
            </div>
        </div>
        <div id="divModal"></div>
        <script type="text/javascript" src="../Scripts/MensajeModal.js"></script>
    </form>
</body>
</html>
