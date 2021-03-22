package com.emids.da.repository;

import java.io.Serializable;

public interface Repository<Entity, Id extends Serializable> {

  /**
   * Get the persisted instance with the given id
   *
   * @param id id to be searched
   * @return returns an Entity object
   */
  Entity findById(Id id);
}
