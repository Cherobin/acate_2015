<?php
$app->group('/company', function() use($app){
    $companyController = new CompanyController();
    
    $app->get('/list', function() use ($app, $companyController){
        $list = $companyController->listAll();
        include_once 'api/view/company/companyListView.php';
    });
    
    $app->get('/new', function() use ($app, $companyController){
        include_once 'api/view/company/companyNewView.php';
    });
    
    $app->post('/new', function() use ($app, $companyController){
        $post = $app->request->params ();
        $name = @$post['name'];
        $description = @$post['description'];
        $logo = @$_FILES['logo'];
        $link = @$post['link'];
        
        if(!empty($name) && !empty($description) && !empty($logo) && !empty($link)){
            $company = new Company();
            $company->name = $name;
            $company->description = $description;
            $company->link = $link;
            $companyController->insert($company, $logo);
        }else{
            $app->pass();
        }
        
    });
});