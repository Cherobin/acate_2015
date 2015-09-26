<?php

class RoomController {
    
    function insert($room){
        $dao = new RoomDao();
        $nextId = $dao->nextId();
        
        $room->qrcode = 'upload/qrcode/'.uniqid().'.png';
        QRcode::png(BASE_URL.'/room/'.$nextId, $room->qrcode); 
        
        $dao->insert($room);
    }
    
    function listAll(){
        $dao = new RoomDao();
        return $dao->listAll();
    }
    
}
