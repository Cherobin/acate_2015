<?php
abstract class Dao {
    protected $conn;
    
    public function __construct() {
        $this->conn = \Slim\Slim::getInstance()->conn;
    }

    abstract public function getById($id);    
    abstract public function update($object);
    abstract public function insert($object);
    abstract public function delete($object);
}
