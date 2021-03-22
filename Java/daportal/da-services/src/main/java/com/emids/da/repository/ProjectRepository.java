package com.emids.da.repository;

import com.emids.da.model.Project;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class ProjectRepository extends AbstractRepository<Project> {

  @Override
  public Project findById(Long id) {
    return find(Project.class, id);
  }
}
