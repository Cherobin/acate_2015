<?php
$app->group('/agenda', function() use($app){
    $agendaController = new AgendaController();
    
    $app->get('/list', function() use ($app, $agendaController){
        $list = $agendaController->listAll();
        $app->render("agenda/agendaListView.php", array("list" => $list));
        $app->conn = null;
    });
    
    $app->get('/list/json', function() use ($app, $agendaController){
        header('Access-Control-Allow-Origin: *');
        $list = $agendaController->listAll();
        echo json_encode($list);
        $app->conn = null;
    });
    
    $app->get('/:id/new', function($id) use ($app, $agendaController){
        $list = $agendaController->listAll();
        $app->render("agenda/agendaNewView.php", array(
            "pageTitle" => "Agendar horário",
            "customHeader" => '<link href="'.BASE_URL.'/css/bootstrap-datetimepicker.min.css" rel="stylesheet">',
            "includeFooter" => 'api/view/agenda/footerInclude/agendaNewViewFooterInclude.php',
            "list" => $list
        ));
        $app->conn = null;
    });
    
    $app->post('/:id/new', function($id) use ($app, $agendaController){
        $post = $app->request->params ();
        $owner = @$post['owner'];
        $dateStart = @$post['dateStart'];
        $dateFinish = @$post['dateFinish'];
        
        if(!empty($owner) && !empty($dateStart) && !empty($dateFinish)){
            $agenda = new Agenda();
            $agenda->roomId = $id;
            $agenda->owner = $owner;
            $agenda->dateStart = $dateStart;
            $agenda->dateFinish = $dateFinish;
            $agendaController->insert($agenda);
            $app->conn = null;

	    $app->redirect("/agenda/list");
        }else{
            $app->pass();
        }
    });
});
