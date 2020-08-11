import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RouteService {
  constructor() {}

  private scheme:string = "http";
  private host:string = "192.168.0.103";
  private port: string = "5002";
  private version: string = "v1";

  private routes = {
    activity: {
      'get all': 'activities',
      'add one': 'activities',
      'get one': (activityId: string) => `activities/${activityId}`,
      delete: (activityId: string) => `activities/${activityId}`,
    },
    activityType: {
      'get all': 'activities/types',
      'add one': 'activities/types',
      delete: (activityTypeId: string) => `activities/types/${activityTypeId}`,
    },
    admin: {
      'get users': 'admin/users',
      'get userTypes': 'admin/userTypes',
      'change userType': (userId: string) =>
        `admin/user/${userId}/userType/toggle`,
    },
    authentication: {
      login: 'auth/login',
      register: 'auth/register',
      'change password': 'auth/change-password',
    },
    bucketlist: {
      'get all': 'bucketlists',
      'get one': (bucketlistId: string) => `bucketlists/${bucketlistId}`,
      'add one': (bucketlistId: string, activityId: string) =>
        `bucketlists/${bucketlistId}/activities/${activityId}`,
      change: (bucketlistId: string) =>
        `bucketlists/${bucketlistId}/activities`,
    },
    city: {
      'get all': 'cities',
      'add one': 'cities',
      delete: (cityId: string) => `cities/${cityId}`,
    },
    comment: {
      'get all': (activityId: string) => `activities/${activityId}/comments`,
      'add one': (activityId: string) => `activities/${activityId}/comments`,
      delete: (activityId: string, commentId: string) =>
        `activities/${activityId}/comments/${commentId}`,
    },
    notification: {
      'get all': 'notifications',
    },
    photo: {
      'get all': (activityId: string) => `activities/${activityId}/photos`,
      'add one': (activityId: string) => `activities/${activityId}/photos`,
      delete: (activityId: string, commentId: string) =>
        `activities/${activityId}/photos/${commentId}`,
    },
    rating: {
      'get all': (activityId: string) => `activities/${activityId}/ratings`,
      'add one': (activityId: string) => `activities/${activityId}/ratings`,
    },
  };

  public getRoute(
    entity: string,
    operation: string,
    id1: string = '',
    id2: string = ''
  ): string {
    let end = '';
    if (id1 != '' && id2 != '') {
      end = this.routes[entity][operation](id1, id2);
    } else if (id1 != '') {
      end = this.routes[entity][operation](id1, id2);
    } else {
      end = this.routes[entity][operation];
    }
    return `${this.scheme}://${this.host}:${this.port}/api/${this.version}/${end}`;
  }
}
