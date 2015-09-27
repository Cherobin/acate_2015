<?php
    
$app->get('/map', function() use ($app){
    $app->render("index.php", array());
});

$app->get('/credits', function() use ($app){
    $app->render("credits.php", array("pageTitle" => "Créditos"));
});

$app->get('/', function() use ($app){
    $app->render("mainView.php", array("pageTitle" => "Página principal"));
});
