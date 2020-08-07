import { ActivityModel } from './activity.model';

export type BucketListWithActivitiesModel={
    name: string,
    username: string,
    activities: ActivityModel[]
};