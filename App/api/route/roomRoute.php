<?php
$app->group('/room', function() use($app){
    $roomController = new RoomController();
    
    $app->get('/list', function() use ($app, $roomController){
        $list = $roomController->listAll();
        include_once 'api/view/room/roomListView.php';
    });
    
    $app->get('/new', function() use ($app, $roomController){
        include_once 'api/view/room/roomNewView.php';
    });
    
    $app->post('/new', function() use ($app, $roomController){
        $post = $app->request->params ();
        $name = @$post['name'];
        $chairs = @$post['chairs'];
        
        if(!empty($name) && !empty($chairs)){
            $room = new Room();
            $room->name = $name;
            $room->chairs = $chairs;
            $roomController->insert($room);
        }else{
            $app->pass();
        }
        
    });
});