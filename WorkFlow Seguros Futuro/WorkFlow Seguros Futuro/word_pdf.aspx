﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="word_pdf.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.word_pdf" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Trabajando con checkboxes AngularJS</title>
</head>
<body ng-app="app" ng-controller="appCtrl as vm">
   
    <p>
        <input type="checkbox" ng-model="vm.activo" ng-change="vm.avisar()">
        Este campo es vm.activo y su valor en el modelo es {{ vm.activo }}.
        <br />
        Tiene además un ng-change asociado con el método vm.avisar().
    </p>
    <p>
        <input type="checkbox" ng-model="vm.clarooscuro" ng-true-value="claro" ng-false-value="oscuro" />
        Este campo tiene el value modificado. Ahora vale {{ vm.clarooscuro }}
    </p>
    <p>
        <input type="button" ng-click="vm.activo=true" value="pulsa para cambiar la propiedad del modelo del primer checkbox a true"> Observarás que aunque el estado pueda cambiar, no se invoca al ng-change de ese primer checkbox.
    </p>    

    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.24/angular.min.js"></script>
    <script>
        var app = angular.module("app", [])
        app.controller("appCtrl", function () {
            var vm = this;
            //podríamos inicializar valores del modelo
            //vm.activo = false;

            vm.avisar = function () {
                console.log("cambié");
            }
        });
    </script>
</body>
</html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
