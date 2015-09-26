<?php
class ViewNotFound extends \Slim\View {

    public function render($template, $data = null){
        return "Página não encontrada";
    }
    
}