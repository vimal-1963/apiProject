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
        bat 'dotnet restore'
        bat 'dotnet build'        
      }
      
    }

    stage('Test'){
      steps{
        bat 'echo Runing test on project'
      }
      
    }

    stage('Deliver') {
      steps {
                // Publish your .NET Core Web API project
                bat 'dotnet publish -c Release -o ./publish'
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
