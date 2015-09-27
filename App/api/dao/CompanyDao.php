<?php

class CompanyDao extends Dao{
    
    public function __construct() {
        parent::__construct();
    }
    
    public function nextId(){
        $stmt = $this->conn->prepare('SELECT id FROM company ORDER BY id DESC LIMIT 1');
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        
        return 1 + ($row['id'] == null ? 0 : $row['id']);
    }
    
    public function getById($id){
        $stmt = $this->conn->prepare('SELECT * FROM company WHERE id=:id');
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        
        return new Company($row);
    }
    
    public function listAll(){
        $stmt = $this->conn->prepare('SELECT * FROM company');
        $stmt->execute();
        
        $companys = array();
        while($row = $stmt->fetch(PDO::FETCH_ASSOC)){
            $companys[] = new Company($row);
        }
        
        return $companys;
    }
    
    public function insert($company){
        $stmt = $this->conn->prepare('INSERT INTO company('
                . 'name, link, description, logo, qrcode, pos_x, pos_y'
                . ') VALUES ( '
                . ':name, :link, :description, :logo, :qrcode, :pos_x, :pos_y)');
        $stmt->bindParam(':name', $company->name);
        $stmt->bindParam(':link', $company->link);
        $stmt->bindParam(':description', $company->description);
        $stmt->bindParam(':logo', $company->logo);
        $stmt->bindParam(':qrcode', $company->qrcode);
        $stmt->bindParam(':pos_x', $company->posX);
        $stmt->bindParam(':pos_y', $company->posY);
        
        return $stmt->execute();
    }
    
    public function update($company){        
        $stmt = $this->conn->prepare('UPDATE company SET '
                . 'name = :name, link = :link, qrcode = :qrcode, description = :description, logo = :logo '
                . 'pos_x = :pos_x, pos_y = :pos_y WHERE id=:id');
        $stmt->bindParam(':id', $company->id);
        $stmt->bindParam(':name', $company->name);
        $stmt->bindParam(':description', $company->description);
        $stmt->bindParam(':logo', $company->logo);
        $stmt->bindParam(':link', $company->link);
        $stmt->bindParam(':qrcode', $company->qrcode);
        $stmt->bindParam(':pos_x', $company->posX);
        $stmt->bindParam(':pos_y', $company->posY);
        
        return $stmt->execute();
    }
    
    public function delete($company){
        $stmt = $this->conn->prepare('DELETE FROM company WHERE id=:id ');
        $stmt->bindParam(':id', $company->id);
        
        return $stmt->execute();
    }
}
