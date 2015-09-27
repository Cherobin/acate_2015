<?php
error_reporting(E_ALL ^ E_NOTICE);

define("BASE_URL", 'http://54.232.244.189');

require_once 'Slim/Slim.php';

\Slim\Slim::registerAutoloader();
$app = new \Slim\Slim(array(
    'debug' => true,
    'templates.path' => 'api/view'
));

//Configurações da aplicação
$config = array(
    'database' => array(
        'host' => 'localhost' ,
        'database' => 'acate',
        'username' => 'root',
        'password' => 'hackajam'
    )
);

require_once 'api/index.php';

$app->run();
