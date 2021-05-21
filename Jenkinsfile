pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        sh 'cd java/daportal'
      }
    }

  }
  environment {
    build = 'gc'
  }
}