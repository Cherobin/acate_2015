<?php

class AgendaController {
    
    function insert($agenda){
        $dao = new AgendaDao();
        $dao->insert($agenda);
    }
    
    function listAll(){
        $dao = new AgendaDao();
        return $dao->listAll();
    }
    
}
