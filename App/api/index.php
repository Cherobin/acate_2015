<?php
require_once 'phpqrcode/qrlib.php';

require_once 'api/model/Agenda.php';
require_once 'api/model/Company.php';
require_once 'api/model/Room.php';
require_once 'api/dao/Dao.php';
require_once 'api/dao/AgendaDao.php';
require_once 'api/dao/CompanyDao.php';
require_once 'api/dao/RoomDao.php';
require_once 'api/controller/AgendaController.php';
require_once 'api/controller/CompanyController.php';
require_once 'api/controller/RoomController.php';

require_once 'api/route/mapaRoute.php';
require_once 'api/route/agendaRoute.php';
require_once 'api/route/companyRoute.php';
require_once 'api/route/roomRoute.php';

$app->notFound(function() use($app){
    $app->render("mainView.php", array("pageTitle" => "Página principal"));
});

try{
    $app->conn = new PDO(sprintf('mysql:host=%s;dbname=%s',
        $config['database']['host'], $config['database']['database']),
        $config['database']['username'], $config['database']['password'],
        array(
            PDO::ATTR_PERSISTENT => true, 
            PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION
        )
    );
    $app->conn->exec("set names utf8");
}catch(Exception $e){
    $app->render("errorView.php", array("pageTitle" => "Erro inesperado"));
    $app->stop();
}
