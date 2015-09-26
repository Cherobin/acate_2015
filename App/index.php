<?php
error_reporting(E_ALL ^ E_NOTICE);

define("BASE_URL", 'http://192.168.225.117');

require_once 'Slim/Slim.php';

\Slim\Slim::registerAutoloader();
$app = new \Slim\Slim(array(
    'debug' => true
));

//Configurações da aplicação
$config = array(
    'database' => array(
        'host' => 'localhost' ,
        'database' => 'acate',
        'username' => 'root',
        'password' => 'g1u9t9o4'
    )
);

require_once 'api/index.php';

$app->run();
