<?php

class ViewError extends \Slim\View {

    public function render($template, $data = null){
        return "Erro inexperado";
    }
    
}