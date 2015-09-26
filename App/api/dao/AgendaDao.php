<?php

class AgendaDao extends Dao{
    
    public function __construct() {
        parent::__construct();
    }
    
    public function getById($id){
        $stmt = $this->conn->prepare('SELECT * FROM agenda WHERE id=:id');
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        
        return new Agenda($row);
    }
    
    public function listAll(){
        $stmt = $this->conn->prepare('SELECT * FROM agenda');
        $stmt->execute();
        
        $companys = array();
        while($row = $stmt->fetch(PDO::FETCH_ASSOC)){
            $companys[] = new Agenda($row);
        }
        
        return $companys;
    }
    
    public function insert($agenda){
        $stmt = $this->conn->prepare('INSERT INTO agenda( '
                . 'room_id, date_start, date_finish, owner '
                . ') VALUES ( '
                . ':room_id, :date_start, :date_finish, :owner)');
        $stmt->bindParam(':room_id', $agenda->roomId);
        $stmt->bindParam(':date_start', $agenda->dateStart);
        $stmt->bindParam(':date_finish', $agenda->dateFinish);
        $stmt->bindParam(':owner', $agenda->owner);
        
        return $stmt->execute();
    }
    
    public function update($agenda){        
        $stmt = $this->conn->prepare('UPDATE agenda SET '
                . 'room_id = :room_id, date_start = :date_start, date_finish = :date_finish, owner = :owner'
                . 'WHERE id=:id');
        $stmt->bindParam(':id', $agenda->id);
        $stmt->bindParam(':room_id', $agenda->roomId);
        $stmt->bindParam(':date_start', $agenda->dateStart);
        $stmt->bindParam(':date_finish', $agenda->dateFinish);
        $stmt->bindParam(':owner', $agenda->owner);
        
        return $stmt->execute();
    }
    
    public function delete($agenda){
        $stmt = $this->conn->prepare('DELETE FROM agenda WHERE id=:id ');
        $stmt->bindParam(':id', $agenda->id);
        
        return $stmt->execute();
    }
}
