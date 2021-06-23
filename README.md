# Practical Project: Magic 8 Ball

## Contents
* [Brief](#brief)
   * [Additional Requirements](#additional-requirements)
   * [My Approach](#my-approach)
* [Architecture](#architecture)
   * [Architecture Plan](#architecture-plan)
   * [Database Structure](#database-structure)
   * [CI Pipeline](#ci-pipeline)
* [Project Tracking](#project-tracking)
* [Risk Assessment](#risk-assessment)
* [Front-End Design](#front-end-design)
* [Terraform](#terraform)
* [Testing](#testing)
* [Known Issues](#known-issues)
* [Future Improvements](#future-improvements)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)
* [License](#license)

## Brief
The objective of this project is to create an application that generates “Objects” upon a set of predefined rules.

### Additional Requirements
In addition to what has been set out in the brief, I am also required to use the following techologies for solving the problem:
* Kanban Board: Asana or an equivalent Kanban Board
* Version Control: Git
* CI Server: Azure Pipelines
* Configuration Management: Ansible
* Cloud Platform: Azure
* Infrastructure as Code: Terraform

### My Approach
To achieve this, I have decided to produce a Magic 8-Ball game app. In this game, a sphere that looks like an eight-ball is used for fortune-telling or seeking advice. 
The user must be able to input "yes/no" question, and then submit it or click on the ball to reveal an answer.
Additionally, I would like to allow the user to refer to a database to view all answers given by the ball.

## Architecture
### Architecture Plan
The application has a service-orientated architecture and is composed of 4 services that communicate to generate an output. All four services are ASP.NET Core 5.0 applications: Service 1 implements the MVC design pattern, whereas Service 2, 3 and 4 are RESTful services/web APIs.

#### Service 1
The core service – this renders the HTML needed to interact with the application, it is responsible for communicating with the other services, and finally for persisting some data in a SQL database.

#### Service 2
This service generates a random person that will answer the question.

#### Service 3
This service generates a random answer for the question asked by the user.

#### Service 4
This service creates an "Object" based upon the results of Service 2 and Service 3. The object is represented by an outcome after asking the Magic 8 Ball a question.

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/services-diagram.png" width="65%">

### Migration to Microsoft Azure
Jusitification for migrating apps to Microsoft Azure:
* Deliver updates faster: Automate deployments with continuous integration/continuous deployment (CI/CD) capabilities using DevOps, Bit Bucket and GitHub
* Increase developer productivity: 
  * Start fast and finish faster with source code integration from GitHub, live debugging and publishing directly from Microsoft Visual Studio IDE
  * Easily connect to a database of choice and tap into an ecosystem of Open Source Software packages, APIs, connectors and services through the Azure Marketplace
* Achieve global scale on demand:
  * Get high availability within and across Azure regions
  * Automatically scale vertically and horizontally based on application performance, or customisable rules to handle peaks in workload automatically while minimising costs during off-peak times
* Get actionable insights and analytics: 
  * Azure Monitor can provide detailed views of resource usage
  * Application Insights can provide deeper insights into the app’s throughput, response times, memory and CPU utilisation, and error trends

### Database Structure
The Entity Relationship Diagram (ERD) below illustrates the table within the database that stores the outcomes.

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/erd-outcomes.png" width="35%">

* ID: Unique identifier for the answers
* Response: String value for the outcome after asking the Magic 8 Ball a question
* TimeAsked: DateTime value for the time when a question was asked and answered

### CI Pipeline

The application is fully integrated using the Feature-Branch model into GitHub, which will subsequently be built through GitHub Actions and deployed to Microsoft Azure. If a change is made to the code, the applications are recreated and redeployed.

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/ci-pipeline.png" width="85%">

A YAML file was written for configuring the workflow:
* The workflow is triggered by two events: a push or a pull request on the main branch
* Environment variables are used to specify the .NET Core version and the needed paths for each microservice
* There are 4 jobs that build each service and run in parallel
* Each job has one step with steps (tasks):
  * Setting up .NET Core: Set up the build environment 
  * Restore: Restore packages specified in the .NET Core project .csproj files
  * Build: Build the environment for the .NET Core app
  * Test: Run unit tests by using the xUnit testing framework
  * Publish: Publish the output of the .NET build into a .zip file
  * Login to Azure
  * Create and deploy or redeploy the App Service using an Azure CLI command

A service principal was created using the **az ad sp create-for-rbac** command in the Azure CLI. The output of the command is a JSON object with the role assignment credentials that provide access to the App Service apps. This was used to configure a secret in the GitHub repository, and was then used in the YAML file to login to Azure.

## Project Tracking

## Risk Assessment

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/risk-assessment.png">

## Front-End Design
Basic HTML and CSS were used for creating the frontend, as the use case is not complex. The user can ask a question using the input field, and either press "Enter" on the keyboard or click on the Magic 8 Ball to generate an answer.

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/frontend-home-view.png">

## Terraform

Terraform was employed for automating the provisioning of Azure resources:
* Resource group
* App Service Plan
* Web Applications
* MySQL Server
* MySQL Database

The tool was also used for configuring the resources created:
* Added rules for MySQL Server Firewall:
  * Changed the connection security by adding the current client IP address to allow access to the server
  * Allowed access to other Azure resources
* Connected the FrontEnd web app to MySQL Server

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/terraform-apply.png">

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/terraform-apply-yes.png">

## Testing
The xUnit tool was used for writing unit tests for the controller of each service. The tests check whether the objects generated by services are non-null and have the correct type, and throw an exception if they are null or an incorrect type.
For the frontend service the repostiory pattern 
The Coverlet code coverage framework for C# was used for generating code coverage info during build. Screenshots of the HTML coverage report created using the ReportGenerator commandline tool can be seen below.

<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/coverage-report.png">

## Known Issues
There are no known issues.

## Future Improvements
There are a number of improvements I would like to implement in the future:
* Pull objects from a database, rather than having them in a list
* Add testing for the Home page View
* Add a button on the Home page that allows for the database content to be downloaded as a .csv file

## Authors
Andra Vasilcoiu

## Acknowledgements
* Dara Oladapo
* Ben Hesketh

This project was created as part of QA Cloud Academy training.

## License
This project is licensed under the terms of the MIT license.
