pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        sh 'cd Java/daportal'
      }
    }

    stage('test') {
      steps {
        sh 'pwd'
      }
    }

  }
  environment {
    build = 'gc'
  }
}