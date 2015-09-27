<?php
$app->group('/room', function() use($app){
    $roomController = new RoomController();
    
    $app->get('/list', function() use ($app, $roomController){
        $list = $roomController->listAll();
        $app->render("room/roomListView.php", array("list" => $list));
	$app->conn = null;
    });
    
    $app->get('/new', function() use ($app, $roomController){
        $app->render("room/roomNewView.php", array());
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
	    $app->conn = null;

	    $app->redirect("/room/list");
        }else{
            $app->pass();
        }
        
    });
});
