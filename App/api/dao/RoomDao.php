<?php

class RoomDao extends Dao{
    
    public function __construct() {
        parent::__construct();
    }
    
    public function nextId(){
        $stmt = $this->conn->prepare('SELECT id FROM room ORDER BY id DESC LIMIT 1');
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        
        return 1 + ($row['id'] == null ? 0 : $row['id']);
    }
    
    public function getById($id){
        $stmt = $this->conn->prepare('SELECT * FROM room WHERE id=:id');
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        
        return new Room($row);
    }
    
    public function listAll(){
        $stmt = $this->conn->prepare('SELECT * FROM room');
        $stmt->execute();
        
        $companys = array();
        while($row = $stmt->fetch(PDO::FETCH_ASSOC)){
            $companys[] = new Room($row);
        }
        
        return $companys;
    }
    
    public function insert($room){
        $stmt = $this->conn->prepare('INSERT INTO room('
                . 'name, qrcode, chairs'
                . ') VALUES ( '
                . ':name, :qrcode, :chairs)');
        $stmt->bindParam(':name', $room->name);
        $stmt->bindParam(':qrcode', $room->qrcode);
        $stmt->bindParam(':chairs', $room->chairs);
        
        return $stmt->execute();
    }
    
    public function update($room){        
        $stmt = $this->conn->prepare('UPDATE room SET '
                . 'name = :name, qrcode = :qrcode, chairs = :chairs'
                . 'WHERE id=:id');
        $stmt->bindParam(':id', $room->id);
        $stmt->bindParam(':name', $room->name);
        $stmt->bindParam(':qrcode', $room->qrcode);
        $stmt->bindParam(':chairs', $room->chairs);
        
        return $stmt->execute();
    }
    
    public function delete($room){
        $stmt = $this->conn->prepare('DELETE FROM room WHERE id=:id ');
        $stmt->bindParam(':id', $room->id);
        
        return $stmt->execute();
    }
}
