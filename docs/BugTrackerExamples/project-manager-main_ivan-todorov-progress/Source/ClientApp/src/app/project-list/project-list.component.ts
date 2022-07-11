import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectInfo } from '../model/model';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
})
export class ProjectListComponent {
  public projects: ProjectInfo[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const projectUrl = baseUrl + 'projects';

    http.get<ProjectInfo[]>(projectUrl)
        .subscribe(result => this.projects = result,
                   error => console.error(error));
  }
}
