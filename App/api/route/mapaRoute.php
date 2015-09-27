<?php
    
$app->get('/mapa', function() use ($app, $companyController){
	include_once "api/view/index.php";
});
