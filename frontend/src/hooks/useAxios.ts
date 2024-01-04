import axios, { AxiosRequestConfig } from "axios";
import { useEffect, useState } from "react";
const baseUrl = "https://localhost:7234";
export enum Method {
  GET = "GET",
  POST = "POST",
  PUT = "PUT",
  DELETE = "DELETE",
}
export interface IOptions {
  method: Method;
  route: string;
  data?: any;
  id?: string;
  query?: string;
  token?: string;
}
const useAxios = () => {
  const [data, setData] = useState<any>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<any>(null);

  const buildOptions = (options: IOptions) => {
    let newOptions: AxiosRequestConfig = {
      method: options.method,
      headers: {
        "Content-Type": "application/json"
      },
      url: baseUrl + options.route + (options.id ? `/${options.id}` : "") + (options.query ? options.query : ""),
    };
    if (options.token) {
      newOptions.headers = {
        Authorization: `Bearer ${options.token}`,
      };
    }
    if (options.data) {
      newOptions.data = options.data;
    }
    return newOptions;
  }

  const getData = (options: IOptions) => {
    const opts = buildOptions(options);
    setLoading(true);
    axios(opts)
      .then((res) => {
        setData(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  };
  const postData = (options: IOptions) => {
    const opts = buildOptions(options);
    setLoading(true);
    axios(opts)
      .then((res) => {
        setData(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  }
  const putData = (options: IOptions) => {
    const opts = buildOptions(options);
    setLoading(true);
    axios(opts)
      .then((res) => {
        setData(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  }
  const deleteData = (options: IOptions) => {
    const opts = buildOptions(options);
    setLoading(true);
    axios(opts)
      .then((res) => {
        setData(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  }
  return { data, loading, error, getData, postData, putData, deleteData };
}
export default useAxios;