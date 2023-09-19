import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import agent from "../../app/api/agent";

export const loadProfile = (id: string) => {
  return useQuery({
    queryKey: ["loadProfile"],
    queryFn: () => agent.profile.get(id),
    enabled: Boolean(id),
  });
};

export const uploadPhoto = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (file: File) => agent.profile.uploadPhoto(file),
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["loadProfile"] }),
  });
};

export const setMainPhoto = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (id: string) => agent.profile.setMainPhoto(id),
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["loadProfile"] }),
  });
};

export const deletePhoto = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (id: string) => agent.profile.deletePhoto(id),
    onSuccess: () =>
      queryClient.invalidateQueries({ queryKey: ["loadProfile"] }),
  });
};
