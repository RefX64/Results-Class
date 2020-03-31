export interface IResults {
    resultType: number,
    message: string;
    isSuccess: boolean;
}

export interface IResultsWithValue<T> extends IResults {
    value: T;
}