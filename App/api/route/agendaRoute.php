<?php
$app->group('/agenda', function() use($app){
    $agendaController = new AgendaController();
    
    $app->get('/list', function() use ($app, $agendaController){
        $list = $agendaController->listAll();
        include_once 'api/view/agenda/agendaListView.php';
    });
    
    $app->get('/list/json', function() use ($app, $agendaController){
        $list = $agendaController->listAll();
        echo json_encode($list);
    });
    
    $app->get('/:id/new', function($id) use ($app, $agendaController){
        $list = $agendaController->listAll();
        include_once 'api/view/agenda/agendaNewView.php';
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
            
        }else{
            $app->pass();
        }
        
    });
    
    $app->get('/:id/edit', function() use ($app, $agendaController){
        $list = $agendaController->listAll();
        include_once 'api/view/agenda/agendaNewView.php';
    });
});