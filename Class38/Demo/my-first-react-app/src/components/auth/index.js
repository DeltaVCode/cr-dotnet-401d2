import React from 'react';
import { useAuth } from '../../contexts/auth';

export default function Auth(props)
{
  // stretch goal: support a not flag, i.e. <Auth not> or <Auth not permission='delete'>
  const { children, permission } = props;
  const { user } = useAuth();

  if (!user) return null;

  // Restrict to specific permission
  if (permission) {
    if (user.permissions.includes(permission)) {
      return children;
    } else {
      return null;
    }
  }

  return children;
}