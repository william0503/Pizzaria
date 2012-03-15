<%@ Page Title="Criar BD" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="CriarBD.aspx.cs" Inherits="Pizzaria.CriarBD" ClientIDMode="Static" ViewStateMode="Disabled"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Criar BD
    </h2>
    <p>
        Criar novo Banco de Dados<br/>
        <input type="button" id="BtnCriarBD" value="Criar BD"/>
<%--        <asp:Button ID="BtnCriarBD" runat="server" Text="Criar BD" 
            onclick="BtnCriarBD_Click" />--%>
            <div id="divText"></div>
    </p>
    
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"> </script>
    <script type="text/javascript">
        $("#BtnCriarBD").click(function () {
            var dados = { };
            var request = $.ajax({
                type: "POST",
                url: "CriarBD.aspx?bdCreate=1",
                data: dados
            });

            request.done(function () {
               alert("Banco criado com sucesso");
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        });


    </script>
</asp:Content>
