import { useState, useEffect } from 'react';

function useGetApi(apiMethod: Function, params: any = undefined) {
  const [data, setData] = useState<any>(null);

  useEffect(() => {
    let isMounted = true;

    apiMethod(params)
        .then((result:any) => {
            if (isMounted) {        
                setData(result);
            }
        });

    return () => {
        isMounted = false;
    };
}, [apiMethod, params]);

  return data;
}

export default useGetApi;