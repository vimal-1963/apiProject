pipeline{
  agent any

  stages{
    stage('Checkout'){
      steps{
          git 'https://github.com/vimal-1963/apiProject.git'  
      }
    }

    stage('Build'){
      steps{
        sh 'dotnet restore'
        sh 'dotnet build'        
      }
      
    }

    stage('Test'){
      steps{
        sh 'echo Runing test on project'
      }
      
    }

    
  }

   post {
        success {
            echo 'Pipeline succeeded! You can add additional actions here.'
        }
        failure {
            echo 'Pipeline failed. Take necessary actions.'
        }
    }
}
