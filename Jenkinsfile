pipeline {
    agent any
    environment {
        REPO = "registration/registration-customerfrontend"
        PRIVATE_REPO = "${PRIVATE_DOCKER_REGISTRY}/${REPO}"
        TAG = "${BUILD_TIMESTAMP}"
    }
    stages {
        stage('Git clone') {
            steps {
                git branch: 'master',
                    url: 'https://github.com/LivingSkySchoolDivision/Registration.git'
            }
        }
        stage('Docker build') {
            steps {
                sh "docker build --no-cache -f Dockerfile-FrontEnd -t ${PRIVATE_REPO}:latest -t ${PRIVATE_REPO}:${TAG} ."
                
            }
        }
        stage('Docker push') {
            steps {
                sh "docker push ${PRIVATE_REPO}:${TAG}"
                sh "docker push ${PRIVATE_REPO}:latest"           
            }
        }
    }
    post {
        always {
            deleteDir()
        }
    }
}