# Practical Project: Magic 8 Ball

## Contents
* [Brief](#brief)
   * [Additional Requirements](#additional-requirements)
   * [My Approach](#my-approach)
* [Architecture](#architecture)
   * [Database Structure](#database-structure)
   * [CI Pipeline](#ci-pipeline)
* [Risk Assessment](#risk-assessment)
* [Testing](#testing)
* [Front-End Design](#front-end-design)
* [Known Issues](#known-issues)
* [Future Improvements](#future-improvements)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)

## Brief
The objective of this project is to create an application that generates “Objects” upon a set of predefined rules.

### Additional Requirements
In addition to what has been set out in the brief, I am also required to use the following techologies:
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
<img src="https://github.com/Andra1609/Magic8Ball/blob/main/images/services-diagram.png" width="70%">

## Risk Assessment
![Risk Assessment](https://github.com/Andra1609/Magic8Ball/blob/main/images/services-diagram.png?raw=true)

## Testing

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
