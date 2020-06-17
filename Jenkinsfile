pipeline {
    agent any
    environment {
        REPO_FRONTEND = "registration/registration-customerfrontend"
        REPO_API = "registration/registration-publicapi"
        REPO_NOTIFIER = "registration/registration-notifier"
        TAG = "${BUILD_TIMESTAMP}"
    }
    stages {
        stage('Git clone') {
            steps {
                git branch: 'master',
                    url: 'https://github.com/LivingSkySchoolDivision/Registration.git'
            }
        }
        stage('Docker build - FrontEnd') {
            steps {
                sh "docker build -f Dockerfile-FrontEnd -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_FRONTEND}:latest -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_FRONTEND}:${TAG} ."                
            }
        }
        stage('Docker build - API') {
            steps {
                sh "docker build -f Dockerfile-API -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_API}:latest -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_API}:${TAG} ."                
            }
        }
        stage('Docker build - Notifier') {
            steps {
                sh "docker build -f Dockerfile-Notifier -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_NOTIFIER}:latest -t ${PRIVATE_DOCKER_REGISTRY}/${REPO_NOTIFIER}:${TAG} ."                
            }
        }
        stage('Docker push') {
            steps {
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_FRONTEND}:${TAG}"
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_FRONTEND}:latest" 
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_API}:${TAG}"
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_API}:latest"      
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_NOTIFIER}:${TAG}"
                sh "docker push ${PRIVATE_DOCKER_REGISTRY}/${REPO_NOTIFIER}:latest"           
            }
        }
    }
    post {
        always {
            deleteDir()
        }
    }
}